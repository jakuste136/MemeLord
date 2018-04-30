package com.majstehermuskic.memelordmobile.dependencyinjection.authorization

import com.majstehermuskic.memelordmobile.dependencyinjection.AppModule
import com.majstehermuskic.memelordmobile.dependencyinjection.NetworkModule
import com.majstehermuskic.memelordmobile.dependencyinjection.posts.PostsModule
import com.majstehermuskic.memelordmobile.features.authorization.LoginFragment
import dagger.Component
import javax.inject.Singleton

@Singleton
@Component(modules = arrayOf(
        AppModule::class,
        LoginModule::class,
        NetworkModule::class
))
interface LoginComponent {

    fun inject(loginFragment: LoginFragment)

}