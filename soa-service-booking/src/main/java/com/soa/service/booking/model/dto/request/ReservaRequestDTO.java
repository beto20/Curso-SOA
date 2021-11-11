package com.soa.service.booking.model.dto.request;


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
public class ReservaRequestDTO {
	private Integer reservaId;
	private int cantidadPersonas;
	private String fechaInicio;
	private String fechaFin;
	private PaqueteTuristico paqueteTuristico;
	private int estado;
}
