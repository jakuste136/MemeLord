package com.majstehermuskic.memelordmobile.features.posts.adapter

import android.support.v7.widget.RecyclerView
import android.view.ViewGroup
import com.majstehermuskic.memelordmobile.R
import com.majstehermuskic.memelordmobile.commons.MemePostItem
import com.majstehermuskic.memelordmobile.commons.adapter.ViewType
import com.majstehermuskic.memelordmobile.commons.adapter.ViewTypeDelegateAdapter
import com.majstehermuskic.memelordmobile.commons.extensions.inflate
import com.majstehermuskic.memelordmobile.commons.extensions.loadImg
import kotlinx.android.synthetic.main.posts_item.view.*

/**
 * Created by Bartosz on 2018-03-15.
 */
class PostsDelegateAdapter : ViewTypeDelegateAdapter {
    override fun onCreateViewHolder(parent: ViewGroup) = TurnsViewHolder(parent)

    override fun onBindViewFolder(holder: RecyclerView.ViewHolder, item: ViewType){
        holder as TurnsViewHolder
        holder.bind(item as MemePostItem)
    }

    class TurnsViewHolder(parent: ViewGroup) : RecyclerView.ViewHolder(
            parent.inflate(R.layout.posts_item)) {

        fun bind(item: MemePostItem) = with(itemView){
            post_title.text = item.title
            post_image.loadImg(item.image)
        }
    }
}