package com.majstehermuskic.memelordmobile.dependencyinjection

import dagger.Module
import dagger.Provides
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
        return Retrofit.Builder()
                .baseUrl("http://memelordapp.azurewebsites.net/api/")
                .addConverterFactory(MoshiConverterFactory.create())
                .build()
    }
}