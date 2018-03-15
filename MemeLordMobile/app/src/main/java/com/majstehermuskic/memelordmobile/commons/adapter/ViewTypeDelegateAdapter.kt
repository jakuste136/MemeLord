package com.majstehermuskic.memelordmobile.commons.adapter

import android.support.v7.widget.RecyclerView
import android.view.ViewGroup

/**
 * Created by Bartosz on 2018-03-15.
 */
interface ViewTypeDelegateAdapter {
    fun onCreateViewHolder(parent: ViewGroup): RecyclerView.ViewHolder

    fun onBindViewFolder(holder: RecyclerView.ViewHolder, item: ViewType)
}