using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Widget;
using System;

namespace Showmie.Droid.Utilities
{
    internal class VerificationCountDownTimer : CountDownTimer
    {
        private readonly int verificationTimeout;
        private readonly int interval;
        public long SecondsLeft { get; private set; }
        private TextView timerTextView;
        public event EventHandler FinishedCount;

        public VerificationCountDownTimer(TextView timerTextView, int verificationTimeout, int interval) : base(verificationTimeout, interval)
        {
            this.timerTextView = timerTextView ?? throw new ArgumentNullException(nameof(timerTextView));
            this.verificationTimeout = verificationTimeout;
            this.interval = interval;
        }

        public override void OnFinish()
        {
            FinishedCount?.Invoke(this, EventArgs.Empty);
        }

        public override void OnTick(long millisUntilFinished)
        {
            SecondsLeft = millisUntilFinished / 1000;
            string secondsLeft = SecondsLeft.ToString();
            secondsLeft = secondsLeft.Length == 1 ? "0" + secondsLeft : secondsLeft;
            timerTextView.SetText("00:" + secondsLeft, TextView.BufferType.Normal);
        }
    }

}