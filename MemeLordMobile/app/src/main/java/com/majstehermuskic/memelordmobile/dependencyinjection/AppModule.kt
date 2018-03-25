package com.majstehermuskic.memelordmobile.dependencyinjection

import android.content.Context
import com.majstehermuskic.memelordmobile.MemeLordApp
import dagger.Module
import dagger.Provides
import javax.inject.Singleton

/**
 * Created by Bartosz on 2018-03-22.
 */
@Module
class AppModule(val app: MemeLordApp) {

    @Provides
    @Singleton
    fun provideContext(): Context = app

    @Provides
    @Singleton
    fun provideApplication(): MemeLordApp = app
}