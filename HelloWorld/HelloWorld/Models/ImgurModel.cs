using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld.Models
{
    class ImgurModel
    {
        public class Tags
        {
            public string name { get; set; }
            public string display_name { get; set; }
            public int followers { get; set; }
            public int total_items { get; set; }
            public bool following { get; set; }
            public bool is_whitelisted { get; set; }
            public string background_hash { get; set; }
            public string thumbnail_hash { get; set; }
            public string accent { get; set; }
            public bool background_is_animated { get; set; }
            public bool thumbnail_is_animated { get; set; }
            public bool is_promoted { get; set; }
            public string description { get; set; }
            public string logo_hash { get; set; }
            public string logo_destination_url { get; set; }

        }
        public class Images
        {
            public string id { get; set; }
            public string title { get; set; }
            public string description { get; set; }
            public int datetime { get; set; }
            public string type { get; set; }
            public bool animated { get; set; }
            public int width { get; set; }
            public int height { get; set; }
            public int size { get; set; }
            public int views { get; set; }
            public int bandwidth { get; set; }
            public bool favorite { get; set; }
            public bool nsfw { get; set; }
            public string section { get; set; }
            public string account_url { get; set; }
            public string account_id { get; set; }
            public bool is_ad { get; set; }
            public bool in_most_viral { get; set; }
            public bool has_sound { get; set; }
            public string tags { get; set; }
            public int ad_type { get; set; }
            public string ad_url { get; set; }
            public string edited { get; set; }
            public bool in_gallery { get; set; }
            public string link { get; set; }
            public string comment_count { get; set; }
            public string favorite_count { get; set; }
            public string ups { get; set; }
            public string downs { get; set; }
            public string points { get; set; }
            public string score { get; set; }

        }
        public class Ad_config
        {
            public IList<string> safeFlags { get; set; }
            public string highRiskFlags { get; set; }
            public string unsafeFlags { get; set; }
            public string wallUnsafeFlags { get; set; }
            public bool showsAds { get; set; }

        }
        public class Items
        {
            public string id { get; set; }
            public string title { get; set; }
            public string description { get; set; }
            public int datetime { get; set; }
            public string cover { get; set; }
            public int cover_width { get; set; }
            public int cover_height { get; set; }
            public string account_url { get; set; }
            public int account_id { get; set; }
            public string privacy { get; set; }
            public string layout { get; set; }
            public int views { get; set; }
            public string link { get; set; }
            public int ups { get; set; }
            public int downs { get; set; }
            public int points { get; set; }
            public int score { get; set; }
            public bool is_album { get; set; }
            public string vote { get; set; }
            public bool favorite { get; set; }
            public bool nsfw { get; set; }
            public string section { get; set; }
            public int comment_count { get; set; }
            public int favorite_count { get; set; }
            public string topic { get; set; }
            public int topic_id { get; set; }
            public int images_count { get; set; }
            public bool in_gallery { get; set; }
            public bool is_ad { get; set; }
            public IList<Tags> tags { get; set; }
            public int ad_type { get; set; }
            public string ad_url { get; set; }
            public bool in_most_viral { get; set; }
            public bool include_album_ads { get; set; }
            public IList<Images> images { get; set; }
            public Ad_config ad_config { get; set; }

        }
        public class Data
        {
            public string name { get; set; }
            public string display_name { get; set; }
            public int followers { get; set; }
            public int total_items { get; set; }
            public bool following { get; set; }
            public bool is_whitelisted { get; set; }
            public string background_hash { get; set; }
            public string thumbnail_hash { get; set; }
            public string accent { get; set; }
            public bool background_is_animated { get; set; }
            public bool thumbnail_is_animated { get; set; }
            public bool is_promoted { get; set; }
            public string description { get; set; }
            public string logo_hash { get; set; }
            public string logo_destination_url { get; set; }
            public IList<Items> items { get; set; }

        }
        public class Application
        {
            public Data data { get; set; }
            public bool success { get; set; }
            public int status { get; set; }

        }
    }
}
