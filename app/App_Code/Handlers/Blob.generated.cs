namespace Argon2Id.Handlers
{


    public partial class BlobFactoryConfig : BlobFactory
    {

        public static void Initialize()
        {
            // register blob handlers
            RegisterHandler("ReceiptPicture", "\"dbo\".\"Receipt\"", "\"Picture\"", new string[0], "Receipt Picture", "Receipt", "Picture");
            RegisterHandler("SiteContentData", "\"dbo\".\"SiteContent\"", "\"Data\"", new string[] {
                        "\"SiteContentID\""}, "Site Content Data", "SiteContent", "Data");
        }
    }
}
