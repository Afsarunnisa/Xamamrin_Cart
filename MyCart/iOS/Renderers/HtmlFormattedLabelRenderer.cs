using System;
using System.Collections.Generic;
using System.Text;
using Foundation;
using Xamarin.Forms;


using Xamarin.Forms.Platform.iOS;
using MyCart.Controls;
using MyCart.iOS.Renderers;


[assembly: ExportRenderer(typeof(HtmlFormattedLabel), typeof(HtmlFormattedLabelRenderer))]
namespace MyCart.iOS.Renderers
{
    public class HtmlFormattedLabelRenderer : LabelRenderer
    {
		protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
		{
			base.OnElementChanged(e);

			var view = (HtmlFormattedLabel)Element;
			if (view == null) return;

			var attr = new NSAttributedStringDocumentAttributes();
			var nsError = new NSError();
			attr.DocumentType = NSDocumentType.HTML;

			Control.AttributedText = new NSAttributedString(view.Text, attr, ref nsError);
		}
    }
}

