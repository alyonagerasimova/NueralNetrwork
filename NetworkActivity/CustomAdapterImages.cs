using System.Collections.Generic;
using Android.Content;
using Android.Util;
using Android.Views;
using Android.Widget;
using Java.Lang;
using NueralNetrwork.Network;

namespace NueralNetrwork.NetworkActivity
{
    public class CustomAdapterImages : BaseAdapter
    {
        private List<Image> listData;
        private LayoutInflater layoutInflater;
        private Context context;

        public CustomAdapterImages(Context aContext, List<Image> listData)
        {
            this.context = aContext;
            this.listData = listData;
            layoutInflater = LayoutInflater.From(aContext);
        }

        public override Object GetItem(int position)
        {
            return listData.get(position);
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            ViewHolder holder;
            if (convertView == null)
            {
                convertView = layoutInflater.Inflate(Resource.Layout.list_item_layout, null);
                holder = new ViewHolder();
                holder.flagView = (ImageView)convertView.FindViewById(Resource.Id.imageView_flag);
                holder.countryNameView = (TextView)convertView.FindViewById(Resource.Id.textView_countryName);
                convertView.SetTag(holder);
            }
            else
            {
                holder = (ViewHolder)convertView.GetTag();
            }

            Image country = this.listData.get(position);
            holder.countryNameView.SetText(country.getImageName());

            int imageId = this.getMipmapResIdByName(country.getFlagName());

            holder.flagView.SetImageResource(imageId);

            return convertView;
        }


        public override int Count {
            return listData.size();
    }

    // Find Image ID corresponding to the name of the image (in the directory mipmap).
    public int getMipmapResIdByName(String resName)
    {
        String pkgName = context.getPackageName();
        // Return 0 if not found.
        int resID = context.getResources().getIdentifier(resName, "mipmap", pkgName);
        Log.i("CustomListView", "Res Name: " + resName + "==> Res ID = " + resID);
        return resID;
    }

    static class ViewHolder
    {
        ImageView flagView;
        TextView countryNameView;
    }
}

}