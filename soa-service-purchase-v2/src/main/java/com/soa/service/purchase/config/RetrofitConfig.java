package com.soa.service.purchase.config;

import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

import com.soa.service.purchase.proxy.ReservaApi;

import okhttp3.OkHttpClient;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;

@Configuration
public class RetrofitConfig {

    @Bean
    public Retrofit retrofit() {
    	OkHttpClient.Builder httpClient = new OkHttpClient.Builder();
        return new Retrofit.Builder()
                .baseUrl("http://localhost:8086/")
                .addConverterFactory(GsonConverterFactory.create())
                .client(httpClient.build())
                .build();
    }
    
    @Bean
    public ReservaApi productApi() {
       return retrofit().create(ReservaApi.class);
    }
}
