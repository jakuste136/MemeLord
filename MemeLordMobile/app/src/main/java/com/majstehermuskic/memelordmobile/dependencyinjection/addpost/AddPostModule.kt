package com.majstehermuskic.memelordmobile.dependencyinjection.addpost

import com.majstehermuskic.memelordmobile.api.*
import dagger.Module
import dagger.Provides
import javax.inject.Singleton

@Module
class AddPostModule {
    @Provides
    @Singleton
    fun provideAddPostApi(memeLordApi: MemeLordAPI): AddPostAPI = AddPostRestAPI(memeLordApi)
}