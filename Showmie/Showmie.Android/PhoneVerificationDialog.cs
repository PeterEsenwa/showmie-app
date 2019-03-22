using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Firebase.Auth;
using Java.Lang;
using Showmie.Droid.Utilities;
using System;
using Xamarin.Forms;
using Button = Android.Widget.Button;
using View = Android.Views.View;

namespace Showmie.Droid
{
    internal class PhoneVerificationDialog : Android.Support.V4.App.DialogFragment, View.IOnClickListener
    {
        private const string INPUT_VALUES = "input_values";
        private const string TIMER_COUNT = "timer_count";
        private const string PRE_LOADED = "pre_loaded";
        private readonly int verificationTimeout;

        public VerificationCountDownTimer Timer { get; private set; }
        private bool useTimer = true;
        public EditText firstInput { get; private set; }
        public EditText secondInput { get; private set; }
        public EditText thirdInput { get; private set; }
        public EditText fourthInput { get; private set; }
        public EditText fifthInput { get; private set; }
        public EditText sixthInput { get; private set; }
        public string CodeSent { get; }
        public FirebaseAuth FirebaseAuth { get; }
        public string VerificationId { get; }

        public PhoneVerificationDialog(int verificationTimeout, FirebaseAuth firebaseAuth, string verificationId)
        {
            this.verificationTimeout = verificationTimeout * 1000;
            FirebaseAuth = firebaseAuth;
            VerificationId = verificationId;
        }

        public void OnClick(View v)
        {
            Dismiss();
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //SetStyle(DialogFragmentStyle.Normal, Resource.Style.PhoneVerificationDialogStyle);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            View view = inflater.Inflate(Resource.Layout.PhoneVerification, container, true);
            Button verifyButton = view.FindViewById<Button>(Resource.Id.Verify);
            verifyButton.Click += VerifyButton_Click;
            if (savedInstanceState != null && savedInstanceState.ContainsKey(PRE_LOADED))
            {
                long secondsLeft = savedInstanceState.GetLong(TIMER_COUNT);
                TextView textTimer = view.FindViewById<TextView>(Resource.Id.countdownTimer);

                if (secondsLeft > 0)
                {
                    textTimer.Text = "00:" + secondsLeft.ToString();
                    Timer = new VerificationCountDownTimer(textTimer, (int)secondsLeft, 1000);
                }
                else
                {
                    string[] formerValues = savedInstanceState.GetStringArray(INPUT_VALUES);
                    useTimer = false;
                    textTimer.Text = "00:00";
                    ReadyInputs(formerValues);
                }
            }
            else
            {
                TextView textTimer = view.FindViewById<TextView>(Resource.Id.countdownTimer);
                textTimer.Text = "00:" + verificationTimeout.ToString();
                Timer = new VerificationCountDownTimer(textTimer, verificationTimeout, 1000);
            }

            if (Dialog != null)
            {
                if (useTimer)
                {
                    Timer.FinishedCount += Timer_FinishedCount;
                    Timer.Start();
                }
            }
            return view;
        }

        private async void VerifyButton_Click(object sender, EventArgs e)
        {
            string inputtedCode = firstInput.Text + secondInput.Text + thirdInput.Text + fourthInput.Text + fifthInput.Text + sixthInput.Text;
            PhoneAuthCredential credential = PhoneAuthProvider.GetCredential(VerificationId, inputtedCode);
            try
            {
                IAuthResult signinResult = await FirebaseAuth.SignInWithCredentialAsync(credential);
                if (signinResult != null && signinResult.User != null)
                {
                    Dialog.Dismiss();
                    MessagingCenter.Send(this, "PhoneAuthenticationDone");
                }
                else
                {
                    firstInput.Text = secondInput.Text = thirdInput.Text = fourthInput.Text = fifthInput.Text = sixthInput.Text = "0";
                }
            }
            catch (System.Exception)
            {
                firstInput.Text = secondInput.Text = thirdInput.Text = fourthInput.Text = fifthInput.Text = sixthInput.Text = "0";
            }
            
         
        }

        public override void OnSaveInstanceState(Bundle outState)
        {
            outState.PutBoolean(PRE_LOADED, true);

            outState.PutLong(TIMER_COUNT, Timer.SecondsLeft);

            if ((int)Timer.SecondsLeft == 0)
            {
                string inputOne = firstInput?.Text.Trim() != "" ? firstInput.Text : 0.ToString();
                string inputTwo = secondInput?.Text.Trim() != "" ? secondInput.Text : 0.ToString();
                string inputThree = thirdInput?.Text.Trim() != "" ? thirdInput.Text : 0.ToString();
                string inputFour = fourthInput?.Text.Trim() != "" ? fourthInput.Text : 0.ToString();
                string inputFive = fifthInput?.Text.Trim() != "" ? fifthInput.Text : 0.ToString();
                string inputSix = sixthInput?.Text.Trim() != "" ? sixthInput.Text : 0.ToString();

                string[] inputValues = new string[] { inputOne, inputTwo, inputThree, inputFour, inputFive, inputSix };

                outState.PutStringArray(INPUT_VALUES, inputValues);
            }

            base.OnSaveInstanceState(outState);
        }

        private void Timer_FinishedCount(object sender, EventArgs e)
        {
            ReadyInputs(null);
        }

        private void ReadyInputs(string[] formerValues)
        {
            firstInput = View.FindViewById<EditText>(Resource.Id.number_one);
            secondInput = View.FindViewById<EditText>(Resource.Id.number_two);
            thirdInput = View.FindViewById<EditText>(Resource.Id.number_three);
            fourthInput = View.FindViewById<EditText>(Resource.Id.number_four);
            fifthInput = View.FindViewById<EditText>(Resource.Id.number_five);
            sixthInput = View.FindViewById<EditText>(Resource.Id.number_six);

            firstInput?.AddTextChangedListener(new VerifyTextWatcher(firstInput, secondInput));
            secondInput?.AddTextChangedListener(new VerifyTextWatcher(secondInput, thirdInput));
            thirdInput?.AddTextChangedListener(new VerifyTextWatcher(thirdInput, fourthInput));
            fourthInput?.AddTextChangedListener(new VerifyTextWatcher(fourthInput, fifthInput));
            fifthInput?.AddTextChangedListener(new VerifyTextWatcher(fifthInput, sixthInput));

            firstInput.Enabled = true;

            if (formerValues != null)
            {
                firstInput.Text = formerValues[0];
                secondInput.Text = formerValues[1];
                thirdInput.Text = formerValues[2];
                fourthInput.Text = formerValues[3];
                fifthInput.Text = formerValues[4];
                sixthInput.Text = formerValues[5];
            }
        }

        public interface IOnCompleteListener
        {
            void OnComplete(string InputtedCode);
        }

        private IOnCompleteListener mListener;

        public override void OnAttach(Context context)
        {
            base.OnAttach(context);
            try
            {
                mListener = (IOnCompleteListener)context;
            }
            catch (ClassCastException e)
            {
                throw new ClassCastException(context.ToString() + " must implement OnCompleteListener");
            }
        }

        public override void OnStart()
        {
            int width = ViewGroup.LayoutParams.MatchParent;
            int height = ViewGroup.LayoutParams.MatchParent;
            Dialog.Window.SetLayout(width, height);
            base.OnStart();
        }

        public override void Dismiss()
        {
            Timer.Cancel();
            Timer.FinishedCount += null;
            base.Dismiss();
        }

        protected override void Dispose(bool disposing)
        {
            Timer.Dispose();
            base.Dispose(disposing);
        }
    }
}