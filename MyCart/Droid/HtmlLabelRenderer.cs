using System;
using System.ComponentModel;
using Android.Text;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

using MyCart.Controls;
using MyCart.Droid;

[assembly: ExportRenderer(typeof(HtmlLabel), typeof(HtmlLabelRenderer))]


namespace MyCart.Droid
{
    public class HtmlLabelRenderer : LabelRenderer
    {
        public HtmlLabelRenderer()
        {
        }

		protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
		{
			base.OnElementChanged(e);

			Control?.SetText(Html.FromHtml(Element.Text), TextView.BufferType.Spannable);
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (e.PropertyName == Label.TextProperty.PropertyName)
			{
				Control?.SetText(Html.FromHtml(Element.Text), TextView.BufferType.Spannable);
			}
		}

    }
}
