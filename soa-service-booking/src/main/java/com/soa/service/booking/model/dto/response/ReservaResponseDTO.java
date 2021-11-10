package com.soa.service.booking.model.dto.response;

import java.time.LocalDateTime;

import com.soa.service.booking.model.domain.PaqueteTuristico;

import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Getter
@Setter
@Builder
@AllArgsConstructor
@NoArgsConstructor
public class ReservaResponseDTO {
	private Integer id;
	private int cantidadPersonas;
	private String fechaInicio;
	private String fechaFin;
	private PaqueteTuristico paqueteTuristico;
	private int estado;
}
