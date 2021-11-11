package com.soa.service.booking.web;


import java.util.List;

import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.soa.service.booking.business.ReservaBusiness;
import com.soa.service.booking.model.domain.Reserva;
import com.soa.service.booking.model.dto.request.ReservaRequestDTO;
import com.soa.service.booking.model.dto.response.ReservaCompleteDTO;
import com.soa.service.booking.model.dto.response.ReservaResponseDTO;

import lombok.RequiredArgsConstructor;

@RestController
@RequestMapping("reservas")
@RequiredArgsConstructor
public class ReservaController {

	private final ReservaBusiness business;
	
	
	@GetMapping
	public List<Reserva> listarReservas() {
		return business.listar();
	}
	
	@GetMapping("/{id}")
	public ReservaResponseDTO buscarReservaPorId(@PathVariable("id") Integer id) {
		return business.buscar(id);
	}
	
	@PostMapping
	public ReservaResponseDTO registrarReserva(@RequestBody ReservaRequestDTO dto) {
		return business.registrar(dto);
	}
	
	@PutMapping("/{id}")
	public void actualizarReserva(@RequestBody ReservaRequestDTO dto, @PathVariable("id") Integer id) {
		business.modificar(id, dto);
	}
	
	@DeleteMapping("/{id}")
	public void cancelarReserva(@PathVariable("id") Integer id) {
		business.cancelar(id);
	}
	
	
	@GetMapping("/response/{id}")
	public ReservaCompleteDTO reserva(@PathVariable("id") Integer id) {
		return business.reserva(id);
	}
	
}
