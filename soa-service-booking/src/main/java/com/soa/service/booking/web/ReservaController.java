package com.soa.service.booking.web;

import java.util.Optional;

import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.soa.service.booking.business.impl.ReservaBusinessImpl;
import com.soa.service.booking.model.domain.Cliente;
import com.soa.service.booking.model.domain.Reserva;
import com.soa.service.booking.repository.ClienteRepository;

import lombok.RequiredArgsConstructor;

@RestController
@RequestMapping("reservas")
@RequiredArgsConstructor
public class ReservaController {

	private final ReservaBusinessImpl business;
	private final ClienteRepository repo;

	@PostMapping("/cliente")
	public Cliente save(@RequestBody Cliente cliente) {
		return repo.save(cliente);
	}
	
	@GetMapping("/{id}")
	public Optional<Reserva> getById(@PathVariable("id") Integer id) {
		return business.buscarReservar(id);
	}
	
	@PostMapping("/")
	public Reserva saveNewBooking(@RequestBody Reserva reserva) {
		return business.reservarPaquete(reserva);
	}
	
	@PutMapping("/{id}")
	public Optional<Reserva> updateBooking(@RequestBody Reserva reserva, @PathVariable("id") Integer id) {
		return business.modificarReserva(id, reserva);
	}
	
	@DeleteMapping("/{id}")
	public void cancelBooking(@PathVariable("id") Integer id) {
		business.cancelarReserva(id);
	}
}
