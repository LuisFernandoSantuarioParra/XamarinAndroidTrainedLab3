using Android.App;
using Android.Widget;
using Android.OS;

namespace AndroidApp
{
    [Activity(Label = "AndroidApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Validate();

            var Helper = new SharedProject1.MySharedCode();
            new AlertDialog.Builder(this).SetMessage(Helper.GetFilePath("demo.dat")).Show();
            // Set our view from the "main" layout resource
            // SetContentView (Resource.Layout.Main);
        }
        private async void Validate() {
            var ServiceClient = new SALLab03.ServiceClient();
            string StudentEmail = "shadowghost-1996@hotmail.com";
            string Password = "santuario1";
            string myDevice = Android.Provider.Settings.Secure.GetString(ContentResolver,Android.Provider.Settings.Secure.AndroidId);
            var Result = await ServiceClient.ValidateAsync(StudentEmail,Password,myDevice);

            Android.App.AlertDialog.Builder Builder = new AlertDialog.Builder(this);
            AlertDialog Alert = Builder.Create();
            Alert.SetTitle("Resultado de la Verificación");
            Alert.SetIcon(Resource.Drawable.Icon);
            Alert.SetMessage($"{Result.Status}\n{Result.Fullname}\n{Result.Token}");
            Alert.SetButton("OK",(s , ev )=> { });
            Alert.Show();
        }
    }
}

