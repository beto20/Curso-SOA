package com.soa.service.booking.business.impl;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

import org.springframework.stereotype.Service;

import com.soa.service.booking.business.ReservaBusiness;
import com.soa.service.booking.model.domain.Cliente;
import com.soa.service.booking.model.domain.Reserva;
import com.soa.service.booking.repository.ClienteRepository;
import com.soa.service.booking.repository.ReservaRepository;

import lombok.RequiredArgsConstructor;

@Service
@RequiredArgsConstructor
public class ReservaBusinessImpl implements ReservaBusiness {

	private final ReservaRepository repository;
	private final ClienteRepository clienteRepository;
	
	@Override
	public Reserva reservarPaquete(Reserva reserva) {
		return repository.save(reserva);
	}
	
	public Reserva reservar(Integer clienteId, Reserva reserva) {
		return clienteRepository.findById(clienteId)
				.map(cliente -> {
					Cliente c = new Cliente();
					List<Reserva> listReserva = new ArrayList<Reserva>();
					listReserva.add(reserva)
					c.setListReserva(listReserva);
					return c;
				}).map(asda -> {
					
				});
	}

	@Override
	public Optional<Reserva> buscarReservar(Integer id) {
		 return repository.findById(id);
	}
	
	@Override
	public Optional<Reserva> modificarReserva(Integer id, Reserva reserva) {
		return repository.findById(id).map(reservaEncontrada -> {
			Reserva reservaNueva = new Reserva();
			reservaNueva.setId(id);
			
			reservaNueva.setFechaInicio(reserva.getFechaInicio());
			reservaNueva.setFechaFin(reserva.getFechaFin());
			
			return reservaNueva;
		}).map(reservaEditada -> repository.save(reservaEditada));
	}
	
	@Override
	public void cancelarReserva(Integer id) {
		repository.deleteById(id);
	}
}
