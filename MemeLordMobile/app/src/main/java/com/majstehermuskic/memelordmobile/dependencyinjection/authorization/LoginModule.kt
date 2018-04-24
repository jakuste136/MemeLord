package com.majstehermuskic.memelordmobile.dependencyinjection.authorization

import com.majstehermuskic.memelordmobile.api.LoginAPI
import com.majstehermuskic.memelordmobile.api.LoginRestAPI
import com.majstehermuskic.memelordmobile.api.MemeLordAPI
import dagger.Module
import dagger.Provides
import javax.inject.Singleton

@Module
class LoginModule {
        @Provides
        @Singleton
        fun provideLoginApi(memeLordApi: MemeLordAPI): LoginAPI = LoginRestAPI(memeLordApi)
}