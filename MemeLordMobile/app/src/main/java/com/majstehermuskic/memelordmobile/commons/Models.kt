package com.majstehermuskic.memelordmobile.commons

import com.majstehermuskic.memelordmobile.commons.adapter.AdapterConstants
import com.majstehermuskic.memelordmobile.commons.adapter.ViewType

/**
 * Created by Bartosz on 2018-03-15.
 */
data class MemePostItem(
        val title: String,
        val image: String
) : ViewType{
    override fun getViewType() = AdapterConstants.POSTS
}
