namespace Sitecore.Support.Shell.Framework.Commands
{
    using System.Collections.Specialized;
    using System.Web;
    using Sitecore.Data;
    using Sitecore.Data.Items;
    using Sitecore.Diagnostics;
    using Sitecore.Shell.Framework.Commands;

    public class ArchiveVersion : Sitecore.Shell.Framework.Commands.ArchiveVersion
    {
        public override void Execute(CommandContext context)
        {
            Assert.ArgumentNotNull(context, "context");
            if (context.Items.Length == 1)
            {
                Item item = context.Items[0];
                NameValueCollection nameValueCollection = new NameValueCollection();
                nameValueCollection["database"] = item.Database.Name;
                nameValueCollection["item"] = item.ID.ToString();
                nameValueCollection["language"] = item.Language.Name;
                nameValueCollection["version"] = ItemUri.Parse(HttpContext.Current.Request.Form["__CurrentItem"]).Version.ToString();
                Sitecore.Context.ClientPage.Start(this, "Run", nameValueCollection);
            }
        }
    }
}