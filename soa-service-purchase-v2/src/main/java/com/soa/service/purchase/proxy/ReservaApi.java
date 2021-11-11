package com.soa.service.purchase.proxy;

import com.soa.service.purchase.model.domain.Reserva;

import retrofit2.Call;
import retrofit2.http.GET;
import retrofit2.http.Path;

public interface ReservaApi {
	
	@GET("/reservas/response/{reservaId}")
	public Call<Reserva> obtenerReserva(@Path("reservaId") Integer reservaId); 
}
 