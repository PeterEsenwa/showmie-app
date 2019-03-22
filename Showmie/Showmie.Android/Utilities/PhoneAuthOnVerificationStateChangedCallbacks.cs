using Android.Util;
using Firebase;
using Firebase.Auth;
using System;

namespace Showmie.Droid.Utilities
{
    internal class PhoneAuthOnVerificationStateChangedCallbacks : PhoneAuthProvider.OnVerificationStateChangedCallbacks
    {
        public event EventHandler CodeSent;
        public event EventHandler VerificationFailed;
        public event EventHandler VerificationCompleted;

        public string VerificationId { get; private set; }
        public PhoneAuthProvider.ForceResendingToken ResendingToken { get; private set; }

        public override void OnVerificationCompleted(PhoneAuthCredential credential)
        {
            Log.Debug("OnVerificationCompleted", "Worked");
            VerificationCompleted?.Invoke(this, new PhoneAuthCompletedEventArgs(credential));
        }

        public override void OnVerificationFailed(FirebaseException exception)
        {
            Log.Debug("OnVerificationFailed", exception.GetType().ToString());
            Log.Debug("OnVerificationFailed", exception.Class.ToString());
            VerificationCompleted?.Invoke(this, new PhoneAuthFailedEventArgs(exception));
        }

        public override void OnCodeSent(string verificationId, PhoneAuthProvider.ForceResendingToken forceResendingToken)
        {
            base.OnCodeSent(verificationId, forceResendingToken);
            VerificationId = verificationId;
            ResendingToken = forceResendingToken;
            CodeSent?.Invoke(this, new PhoneAuthCodeSentEventArgs(verificationId));
        }
    }

    class PhoneAuthCompletedEventArgs : EventArgs
    {
        public PhoneAuthCompletedEventArgs(PhoneAuthCredential credential)
        {
            Credential = credential ?? throw new ArgumentNullException(nameof(credential));
        }

        public PhoneAuthCredential Credential { get; }
    }

    class PhoneAuthCodeSentEventArgs : EventArgs
    {
        public PhoneAuthCodeSentEventArgs(string code)
        {
            Code = code;
        }

        public string Code { get; }
    }

    class PhoneAuthFailedEventArgs : EventArgs
    {
        public PhoneAuthFailedEventArgs(FirebaseException exception)
        {
            Exception = exception ?? throw new ArgumentNullException(nameof(exception));
        }

        public FirebaseException Exception { get; }
    }
}