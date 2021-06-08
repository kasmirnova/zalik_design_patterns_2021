using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Reflection;
using System.IO;

namespace YearCursWork
{
    public partial class MainPage : ContentPage
    {
        ImageModel model;
        public MainPage()
        {

            model = new ImageModel();
            BindingContext = model;
            InitializeComponent();
            MessagingCenter.Subscribe<byte[]>(this, "ImageSelected", (args) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    var source = ImageSource.FromStream(() => new MemoryStream(args));
                    SwitchView(source);
                });

            });

            //ImgEditor.Source = ImageSource.FromResource("YearCursWork.testim.jpg");
        }
        private async void SwitchView(ImageSource source)
        {
            await Navigation.PushAsync(new Redaction() { ImageSource = source });
        }

        void OpenGalleryTapped(object sender, System.EventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                var fileName = SetImageFileName();
                DependencyService.Get<CameraInterface>().LaunchGallery(FileFormatEnum.JPEG, fileName);
            });
        }

        void ImageTapped(object sender, System.EventArgs e)
        {
            LoadFromStream((sender as Image).Source);
        }

        private async void LoadFromStream(ImageSource source)
        {
            await Navigation.PushAsync(new Redaction() { ImageSource = source });
        }
        void TakeAPhotoTapped(object sender, System.EventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                var fileName = SetImageFileName();
                DependencyService.Get<CameraInterface>().LaunchCamera(FileFormatEnum.JPEG, fileName);
            });
        }

        private string SetImageFileName(string fileName = null)
        {
            if (Device.RuntimePlatform == Device.Android)
            {
                if (fileName != null)
                    App.ImageIdToSave = fileName;
                else
                    App.ImageIdToSave = App.DefaultImageId;

                return App.ImageIdToSave;
            }
            else
            {
                if (fileName != null)
                {
                    App.ImageIdToSave = fileName;
                    return fileName;
                }
                else
                    return null;
            }
        }
    }

    class ImageModel
    {
        public ImageSource TakePic { get; set; }
        public ImageSource TakePicSelected { get; set; }
        public ImageSource ChooseImage { get; set; }
        public ImageSource ChooseImageSelected { get; set; }

        public ImageModel()
        {
            ChooseImage = ImageSource.FromResource("IECameraAndGallery.Icons.Gallery_S.png", typeof(App).GetTypeInfo().Assembly);//GallerySelected
            TakePic = ImageSource.FromResource("IECameraAndGallery.Icons.Take_Photo_W.png", typeof(App).GetTypeInfo().Assembly);
            ChooseImageSelected = ImageSource.FromResource("IECameraAndGallery.Icons.Gallery_W.png", typeof(App).GetTypeInfo().Assembly);
            TakePicSelected = ImageSource.FromResource("IECameraAndGallery.Icons.Take_Photo_S.png", typeof(App).GetTypeInfo().Assembly);
        }
    }
}
