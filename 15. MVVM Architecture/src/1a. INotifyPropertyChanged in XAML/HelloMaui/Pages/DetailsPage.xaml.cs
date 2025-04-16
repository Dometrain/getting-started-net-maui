using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloMaui;

public partial class DetailsPage : BaseContentPage<DetailsViewModel>
{
	public DetailsPage(DetailsViewModel detailsViewModel) : base(detailsViewModel)
	{
		InitializeComponent();
	}
}