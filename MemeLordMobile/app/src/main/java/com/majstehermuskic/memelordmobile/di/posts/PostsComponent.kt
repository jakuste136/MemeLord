package com.majstehermuskic.memelordmobile.di.posts

import com.majstehermuskic.memelordmobile.di.AppModule
import com.majstehermuskic.memelordmobile.di.NetworkModule
import com.majstehermuskic.memelordmobile.features.posts.PostsFragment
import dagger.Component
import javax.inject.Singleton

/**
 * Created by Bartosz on 2018-03-22.
 */
@Singleton
@Component(modules = arrayOf(
        AppModule::class,
        PostsModule::class,
        NetworkModule::class
))
interface PostsComponent {

    fun inject(postsFragment: PostsFragment)

}