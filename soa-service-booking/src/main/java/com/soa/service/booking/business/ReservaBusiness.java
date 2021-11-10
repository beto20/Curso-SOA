package com.soa.service.booking.business;


import java.util.List;

import com.soa.service.booking.model.domain.Reserva;
import com.soa.service.booking.model.dto.request.ReservaRequestDTO;
import com.soa.service.booking.model.dto.response.ReservaResponseDTO;

public interface ReservaBusiness {

	public List<Reserva> listar();
	public ReservaResponseDTO registrar(ReservaRequestDTO dto);
	public ReservaResponseDTO buscar(Integer id);
	public void modificar(Integer id, ReservaRequestDTO dto);
	public void cancelar(Integer id);
}
