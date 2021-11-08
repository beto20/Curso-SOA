package com.soa.service.booking.business;

import java.util.Optional;

import com.soa.service.booking.model.domain.Reserva;

public interface ReservaBusiness {

	public Reserva reservarPaquete(Reserva reserva);
	public Optional<Reserva> buscarReservar(Integer id);
	public Optional<Reserva> modificarReserva(Integer id, Reserva reserva);
	public void cancelarReserva(Integer id);
}
