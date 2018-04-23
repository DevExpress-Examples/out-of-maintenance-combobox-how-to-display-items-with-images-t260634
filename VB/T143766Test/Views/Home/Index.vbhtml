@Code
    ViewBag.Title = "СomboBox - Image in Edit Box"
End Code

<h2>Image in Edit Box</h2>
@Code
    Dim obj As System.Xml.Linq.XDocument = System.Xml.Linq.XDocument.Load(Server.MapPath("~/App_Data/Charts.xml"))
    
End Code

@Html.DevExpress().ComboBox(
    Sub(settings)
            settings.Name = "ComboBox"

            settings.Properties.ValueField = "Name"
            settings.Properties.TextField = "Text"
            settings.Properties.ImageUrlField = "ImageUrl"
            settings.Properties.ItemImage.Width = 24
            settings.Properties.ItemImage.Height = 24
            settings.SelectedIndex = 0
            settings.Properties.ShowImageInEditBox = True
    End Sub).BindList(obj.Descendants("Chart").Select(Function(x) New With {
        .Name = x.Attribute("Name").Value,
        .Text = x.Attribute("Text").Value,
       .ImageUrl = Url.Content(x.Attribute("ImageUrl").Value)
    }).ToList()).GetHtml()