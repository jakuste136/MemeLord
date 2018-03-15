package com.majstehermuskic.memelordmobile.features.posts.adapter

import android.support.v7.widget.RecyclerView
import android.view.ViewGroup
import com.majstehermuskic.memelordmobile.R
import com.majstehermuskic.memelordmobile.commons.adapter.ViewType
import com.majstehermuskic.memelordmobile.commons.adapter.ViewTypeDelegateAdapter
import com.majstehermuskic.memelordmobile.commons.extensions.inflate

/**
 * Created by Bartosz on 2018-03-15.
 */
class LoadingDelegateAdapter : ViewTypeDelegateAdapter {

    override fun onCreateViewHolder(parent: ViewGroup) = TurnsViewHolder(parent)

    override fun onBindViewFolder(holder: RecyclerView.ViewHolder, item: ViewType) {

    }

    class TurnsViewHolder(parent: ViewGroup): RecyclerView.ViewHolder(
        parent.inflate(R.layout.posts_item_loading)){
    }
}