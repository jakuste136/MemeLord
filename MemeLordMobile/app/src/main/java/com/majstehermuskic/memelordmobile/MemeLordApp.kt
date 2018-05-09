package com.majstehermuskic.memelordmobile

import android.app.Application
import com.majstehermuskic.memelordmobile.dependencyinjection.AppModule
import com.majstehermuskic.memelordmobile.dependencyinjection.addpost.AddPostComponent
import com.majstehermuskic.memelordmobile.dependencyinjection.addpost.DaggerAddPostComponent
import com.majstehermuskic.memelordmobile.dependencyinjection.authorization.DaggerLoginComponent
import com.majstehermuskic.memelordmobile.dependencyinjection.authorization.LoginComponent
import com.majstehermuskic.memelordmobile.dependencyinjection.displayposts.DaggerPostsComponent
import com.majstehermuskic.memelordmobile.dependencyinjection.displayposts.PostsComponent

/**
 * Created by Bartosz on 2018-03-22.
 */
class MemeLordApp: Application() {

    companion object {
        lateinit var postsComponent: PostsComponent
        lateinit var loginComponent: LoginComponent
        lateinit var addPostComponent: AddPostComponent
    }

    override fun onCreate() {
        super.onCreate()
        postsComponent = DaggerPostsComponent.builder()
                .appModule(AppModule(this))
                .build()

        loginComponent = DaggerLoginComponent.builder()
                .appModule(AppModule(this))
                .build()

        addPostComponent = DaggerAddPostComponent.builder()
                .appModule(AppModule(this))
                .build()
    }
}