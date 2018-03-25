package com.majstehermuskic.memelordmobile.dependencyinjection.posts

import com.majstehermuskic.memelordmobile.api.MemeLordAPI
import com.majstehermuskic.memelordmobile.api.PostsAPI
import com.majstehermuskic.memelordmobile.api.PostsRestAPI
import dagger.Module
import dagger.Provides
import retrofit2.Retrofit
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
    fun provideMemeLordApi(retrofit: Retrofit): MemeLordAPI = retrofit.create(MemeLordAPI::class.java)
}