package com.majstehermuskic.memelordmobile

import android.app.Application
import com.majstehermuskic.memelordmobile.di.AppModule
import com.majstehermuskic.memelordmobile.di.posts.DaggerPostsComponent
import com.majstehermuskic.memelordmobile.di.posts.PostsComponent

/**
 * Created by Bartosz on 2018-03-22.
 */
class MemeLordApp: Application() {

    companion object {
        lateinit var postsComponent: PostsComponent
    }

    override fun onCreate() {
        super.onCreate()
        postsComponent = DaggerPostsComponent.builder()
                .appModule(AppModule(this))
                .build()
    }
}