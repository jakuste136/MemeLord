package com.majstehermuskic.memelordmobile.dependencyinjection.displayposts

import com.majstehermuskic.memelordmobile.api.MemeLordAPI
import com.majstehermuskic.memelordmobile.api.PostsAPI
import com.majstehermuskic.memelordmobile.api.PostsRestAPI
import com.majstehermuskic.memelordmobile.features.displayposts.adapter.PostsAdapter
import dagger.Module
import dagger.Provides
import javax.inject.Singleton

/**
 * Created by Bartosz on 2018-03-22.
 */
@Module
class PostsModule {

    @Provides
    @Singleton
    fun providePostsApi(memeLordApi: MemeLordAPI): PostsAPI = PostsRestAPI(memeLordApi)

    @Provides
    @Singleton
    fun providePostsAdapter() = PostsAdapter()
}