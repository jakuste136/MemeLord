package com.majstehermuskic.memelordmobile.features.posts.adapter

import android.support.v4.util.SparseArrayCompat
import android.support.v7.widget.RecyclerView
import android.view.ViewGroup
import com.majstehermuskic.memelordmobile.commons.MemePostItem
import com.majstehermuskic.memelordmobile.commons.adapter.AdapterConstants
import com.majstehermuskic.memelordmobile.commons.adapter.ViewType
import com.majstehermuskic.memelordmobile.commons.adapter.ViewTypeDelegateAdapter
import java.util.*

/**
 * Created by Bartosz on 2018-03-15.
 */
class PostsAdapter : RecyclerView.Adapter<RecyclerView.ViewHolder>() {

    private var items: ArrayList<ViewType>
    private var delegateAdapters = SparseArrayCompat<ViewTypeDelegateAdapter>()
    private val loadingItem = object : ViewType {
        override fun getViewType() = AdapterConstants.LOADING
    }

    init {
        delegateAdapters.put(AdapterConstants.LOADING, LoadingDelegateAdapter())
        delegateAdapters.put(AdapterConstants.POSTS, PostsDelegateAdapter())
        items = ArrayList()
        items.add(loadingItem)
    }

    override fun getItemCount() = items.size

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int) = delegateAdapters.get(viewType).onCreateViewHolder(parent)

    override fun onBindViewHolder(holder: RecyclerView.ViewHolder, position: Int) {
        delegateAdapters.get(getItemViewType(position)).onBindViewFolder(holder, this.items[position])
    }

    override fun getItemViewType(position: Int) = this.items.get(position).getViewType()

    fun addPosts(posts: List<MemePostItem>) {
            val initPosition = items.size - 1
            items.removeAt(initPosition)
            notifyItemRemoved(initPosition)

            items.addAll(posts)
            items.add(loadingItem)
            notifyItemRangeChanged(initPosition, items.size + 1)
    }

    fun clearAndAddPosts(posts: List<MemePostItem>) {
        items.clear()
        notifyItemRangeRemoved(0, getLastPosition())

        items.addAll(posts)
        items.add(loadingItem)
        notifyItemRangeInserted(0 , items.size)
    }

    fun getPosts(): List<MemePostItem> {
        return items
                .filter { it.getViewType() == AdapterConstants.POSTS }
                .map { it as MemePostItem}
    }

    private fun getLastPosition() = if(items.lastIndex == -1) 0 else items.lastIndex

}