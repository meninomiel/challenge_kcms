﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Challenge_KCMS.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProductDetailsPage : ContentPage
	{
		public ProductDetailsPage (int productId)
		{
			InitializeComponent ();
            this.BindingContext = new DetailsPageViewModel(productId);
		}
	}
}