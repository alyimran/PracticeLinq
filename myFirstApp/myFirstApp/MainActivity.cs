using Android.App;
using Android.Widget;
using Android.OS;

using System.Collections.Generic;
using Android.Content;

namespace myFirstApp
{
    [Activity(Label = "String To Number", MainLauncher = true)]
    public class MainActivity : Activity
    {

        static readonly List<string> phoneNumbers = new List<string>();
        EditText phoneNumberText;
        TextView translatedPhoneWord;
        Button translateButton;

        Button translationHistoryButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

              translationHistoryButton = FindViewById<Button>(Resource.Id.TranslationHistoryButton);
            phoneNumberText = FindViewById<EditText>(Resource.Id.PhoneNumberText);
             translatedPhoneWord = FindViewById<TextView>(Resource.Id.TranslatedPhoneWord);
             translateButton = FindViewById<Button>(Resource.Id.TranslateButton);


            translateButton.Click += (sender, args) => {
                string translatedNumber = string.Empty;

                // Translate user's alphanumeric phone number to numeric
                translatedNumber = Core.PhonewordTranslator.ToNumber(phoneNumberText.Text);
                if (string.IsNullOrWhiteSpace(translatedNumber))
                {
                    translatedPhoneWord.Text = "";
                }
                else
                {
                    translatedPhoneWord.Text = translatedNumber;
                    phoneNumbers.Add(translatedNumber);
                    translationHistoryButton.Enabled = true;
                }
            };

            translationHistoryButton.Click += TranslationHistoryButton_Click;
        }

        private void TranslationHistoryButton_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(TranslationHistoryActivity));
            intent.PutStringArrayListExtra("phone_numbers", phoneNumbers);
            StartActivity(intent);
            Finish();

        }

        private void TranslatedPhoneWord_Click(object sender, System.EventArgs e)
        {
            string translatedNumber = string.Empty;

            // Translate user's alphanumeric phone number to numeric
            translatedNumber = Core.PhonewordTranslator.ToNumber(phoneNumberText.Text);
            if (string.IsNullOrWhiteSpace(translatedNumber))
            {
                translatedPhoneWord.Text = "";
            }
            else
            {
                translatedPhoneWord.Text = translatedNumber;
                phoneNumbers.Add(translatedNumber);
                translationHistoryButton.Enabled = true;
            }
        }
    }
}

