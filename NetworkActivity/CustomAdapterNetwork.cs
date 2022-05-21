// using System.Collections.Generic;
// using Android.Content;
// using Android.Views;
// using Android.Widget;
// using AndroidX.RecyclerView.Widget;
//
// namespace NueralNetrwork.NetworkActivity
// {
//     public class CustomAdapterNetwork : BaseAdapter
//     {
//         private List<Network.Network> listData;
//         private LayoutInflater layoutInflater;
//         private Context context;
//         
//         public CustomAdapterNetwork(Context aContext, ListAdapter adapter) {
//             this.context = aContext;
//             this.listData = listData;
//             layoutInflater = LayoutInflater.From(aContext);
//         }
//         
//         public override Object GetItem(int position)
//         {
//             return listData.get(position);
//         }
//
//         public override long GetItemId(int position)
//         {
//             return position;
//         }
//
//         public override View GetView(int position, View convertView, ViewGroup parent)
//         {
//             CustomAdapterImages.ViewHolder holder;
//             if (convertView == null) {
//                 convertView = layoutInflater.Inflate(Resource.Layout.list_item_layout, null);
//                 holder = new CustomAdapterImages.ViewHolder();
//                 holder.flagView = (ImageView) convertView.FindViewById(Resource.Id.imageView_flag);
//                 holder.countryNameView = (TextView) convertView.FindViewById(Resource.Id.textView_countryName);
//                 convertView.SetTag(holder);
//             } else {
//                 holder = (CustomAdapterImages.ViewHolder) convertView.GetTag();
//             }
//
//             Network.Network network = this.listData.get(position);
//             holder.countryNameView.setText(network.getNameNetwork());
//
//             return convertView;
//         }
//
//         public override int Count { get; }
//     }
// }