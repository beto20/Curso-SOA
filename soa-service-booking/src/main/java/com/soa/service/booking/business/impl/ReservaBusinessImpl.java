package com.soa.service.booking.business.impl;


import java.util.List;

import org.springframework.stereotype.Service;

import com.soa.service.booking.business.ReservaBusiness;
import com.soa.service.booking.model.domain.Reserva;
import com.soa.service.booking.model.dto.request.ReservaRequestDTO;
import com.soa.service.booking.model.dto.response.ReservaResponseDTO;
import com.soa.service.booking.model.mapper.ReservaMapper;
import com.soa.service.booking.repository.ReservaRepository;

import lombok.RequiredArgsConstructor;

@Service
@RequiredArgsConstructor
public class ReservaBusinessImpl implements ReservaBusiness {

	private final ReservaRepository repository;
	
	@Override
	public ReservaResponseDTO registrar(ReservaRequestDTO dto) {
		Reserva reserva = ReservaMapper.mapReservaRequestToReserva(dto);
		//repository.save(reserva);
		return ReservaMapper.mapReservaToResponse(repository.save(reserva));
	}
	
	@Override
	public ReservaResponseDTO buscar(Integer id) {
		 return repository.findById(id)
				 .map(reservaFounded -> ReservaMapper.mapReservaToResponse(reservaFounded))
				 .orElseThrow(() -> new IllegalArgumentException());
	}
	
	@Override
	public void modificar(Integer id, ReservaRequestDTO dto) {
		
		repository.findById(id)
			.map(reservaFounded -> reservaFounded.builder()
					.id(id)
					.cantidadPersonas(dto.getCantidadPersonas())
					.fechaInicio(dto.getFechaInicio())
					.fechaFin(dto.getFechaFin())
					.paqueteTuristico(dto.getPaqueteTuristico())
					.estado(dto.getEstado())
					.build())
			.map(repository::save)
			.orElseThrow(() -> new IllegalArgumentException());
	}
	
	@Override
	public void cancelar(Integer id) {
		repository.deleteById(id);
	}

	@Override
	public List<Reserva> listar() {
		return repository.findAll();
	}
}

