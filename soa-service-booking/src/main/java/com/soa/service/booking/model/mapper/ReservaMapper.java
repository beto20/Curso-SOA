package com.soa.service.booking.model.mapper;

import org.springframework.beans.BeanUtils;

import com.soa.service.booking.model.domain.Reserva;
import com.soa.service.booking.model.dto.request.ReservaRequestDTO;
import com.soa.service.booking.model.dto.response.ReservaResponseDTO;

public class ReservaMapper {
	
	public static ReservaResponseDTO mapReservaToResponse(Reserva reserva) {
		return ReservaResponseDTO.builder()
				.reservaId(reserva.getReservaId())
				.cantidadPersonas(reserva.getCantidadPersonas())
				.fechaInicio(reserva.getFechaInicio())
				.fechaFin(reserva.getFechaFin())
				.paqueteTuristico(reserva.getPaqueteTuristico())
				.estado(reserva.getEstado())
				.build();
	}
	
	public static ReservaResponseDTO mapReservaRequestToResponse(ReservaRequestDTO requestDTO) {
		return ReservaResponseDTO.builder()
				.reservaId(requestDTO.getReservaId())
				.cantidadPersonas(requestDTO.getCantidadPersonas())
				.fechaInicio(requestDTO.getFechaInicio())
				.fechaFin(requestDTO.getFechaFin())
				.paqueteTuristico(requestDTO.getPaqueteTuristico())
				.estado(requestDTO.getEstado())
				.build();
	}
	
	public static Reserva mapReservaRequestToReserva(ReservaRequestDTO requestDTO) {
		Reserva reserva = new Reserva();
		BeanUtils.copyProperties(requestDTO, reserva);
		return reserva;
	}
	
}
