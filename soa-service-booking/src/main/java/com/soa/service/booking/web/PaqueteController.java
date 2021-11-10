package com.soa.service.booking.web;

import java.util.List;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.fasterxml.jackson.annotation.JsonInclude;
import com.soa.service.booking.business.impl.PaqueteBusiness;
import com.soa.service.booking.model.domain.PaqueteTuristico;

import lombok.RequiredArgsConstructor;

@RestController
@RequiredArgsConstructor
@RequestMapping("paquetes")
public class PaqueteController {

	private final PaqueteBusiness business;
	
	@GetMapping
	public List<PaqueteTuristico> listarPaquetes() {
		return business.listPaqueteTuristico();
	}
	
	@PostMapping
	public PaqueteTuristico registrarPaquete(@RequestBody PaqueteTuristico paqueteTuristico) {
		return business.registrar(paqueteTuristico);
	}
}