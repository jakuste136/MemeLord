package com.majstehermuskic.memelordmobile.commons

import android.os.Parcel
import android.os.Parcelable
import com.majstehermuskic.memelordmobile.commons.adapter.AdapterConstants
import com.majstehermuskic.memelordmobile.commons.adapter.ViewType
import com.majstehermuskic.memelordmobile.commons.extensions.createParcel


data class MemePosts(
        val lastId: Int,
        val posts: List<MemePostItem>) : Parcelable {

    companion object {
        @JvmField @Suppress("unused")
        val CREATOR = createParcel{ MemePosts(it) }
    }

    protected constructor(parcelIn: Parcel): this (
            parcelIn.readInt(),
            mutableListOf<MemePostItem>().apply {
                parcelIn.readTypedList(this, MemePostItem.CREATOR)
            }
    )

    override fun writeToParcel(dest: Parcel, flags: Int) {
        dest.writeInt(lastId)
        dest.writeTypedList(posts)
    }

    override fun describeContents() = 0
}

data class MemePostItem(
        val title: String,
        val image: String
) : ViewType, Parcelable{

    companion object {
        @JvmField @Suppress("unused")
        val CREATOR = createParcel{ MemePostItem(it)}
    }

    protected constructor(parcelIn: Parcel) : this(
            parcelIn.readString(),
            parcelIn.readString()
    )

    override fun writeToParcel(dest: Parcel, flags: Int) {
        dest.writeString(title)
        dest.writeString(image)
    }

    override fun describeContents() = 0

    override fun getViewType() = AdapterConstants.POSTS
}
