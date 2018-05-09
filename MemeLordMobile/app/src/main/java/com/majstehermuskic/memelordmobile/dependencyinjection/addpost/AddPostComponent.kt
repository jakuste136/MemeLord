package com.majstehermuskic.memelordmobile.dependencyinjection.addpost

import com.majstehermuskic.memelordmobile.dependencyinjection.AppModule
import com.majstehermuskic.memelordmobile.dependencyinjection.NetworkModule
import com.majstehermuskic.memelordmobile.dependencyinjection.authorization.LoginModule
import com.majstehermuskic.memelordmobile.features.addpost.AddPostFragment
import dagger.Component
import javax.inject.Singleton

@Singleton
@Component(modules = arrayOf(
        AppModule::class,
        AddPostModule::class,
        NetworkModule::class
))
interface AddPostComponent {

    fun inject(addPostFragment: AddPostFragment)

}