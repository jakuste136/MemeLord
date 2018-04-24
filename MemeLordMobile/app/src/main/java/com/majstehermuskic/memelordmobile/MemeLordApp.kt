package com.majstehermuskic.memelordmobile

import android.app.Application
import com.majstehermuskic.memelordmobile.dependencyinjection.AppModule
import com.majstehermuskic.memelordmobile.dependencyinjection.authorization.DaggerLoginComponent
import com.majstehermuskic.memelordmobile.dependencyinjection.authorization.LoginComponent
import com.majstehermuskic.memelordmobile.dependencyinjection.posts.DaggerPostsComponent
import com.majstehermuskic.memelordmobile.dependencyinjection.posts.PostsComponent

/**
 * Created by Bartosz on 2018-03-22.
 */
class MemeLordApp: Application() {

    companion object {
        lateinit var postsComponent: PostsComponent
        lateinit var loginComponent: LoginComponent
    }

    override fun onCreate() {
        super.onCreate()
        postsComponent = DaggerPostsComponent.builder()
                .appModule(AppModule(this))
                .build()

        loginComponent = DaggerLoginComponent.builder()
                .appModule(AppModule(this))
                .build()
    }
}