package com.majstehermuskic.memelordmobile.dependencyinjection

import com.majstehermuskic.memelordmobile.api.MemeLordAPI
import com.majstehermuskic.memelordmobile.features.authorization.AuthorizationInterceptor
import dagger.Module
import dagger.Provides
import okhttp3.OkHttpClient
import retrofit2.Retrofit
import retrofit2.converter.moshi.MoshiConverterFactory
import javax.inject.Singleton

/**
 * Created by Bartosz on 2018-03-22.
 */
@Module
class NetworkModule {

    @Provides
    @Singleton
    fun provideRetrofit(): Retrofit {
        val okClient = OkHttpClient.Builder().addInterceptor(AuthorizationInterceptor()).build()
        return Retrofit.Builder()
                .baseUrl("http://memelordapp.azurewebsites.net/")
                .client(okClient)
                .addConverterFactory(MoshiConverterFactory.create())
                .build()
    }

    @Provides
    @Singleton
    fun provideMemeLordApi(retrofit: Retrofit): MemeLordAPI = retrofit.create(MemeLordAPI::class.java)
}