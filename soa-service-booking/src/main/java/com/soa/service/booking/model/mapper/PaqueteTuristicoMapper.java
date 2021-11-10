package com.soa.service.booking.model.mapper;

import org.springframework.beans.BeanUtils;

import com.soa.service.booking.model.domain.PaqueteTuristico;
import com.soa.service.booking.model.dto.request.PaqueteTuristicoRequestDTO;
import com.soa.service.booking.model.dto.response.PaqueteTuristicoResponseDTO;

public class PaqueteTuristicoMapper {
	
	public static PaqueteTuristicoResponseDTO paqueteCopyOfPaqueteDTO(PaqueteTuristico paqueteTuristico) {
		PaqueteTuristicoResponseDTO dto = new PaqueteTuristicoResponseDTO();
		BeanUtils.copyProperties(paqueteTuristico, dto);
		return dto;
	}	
}
