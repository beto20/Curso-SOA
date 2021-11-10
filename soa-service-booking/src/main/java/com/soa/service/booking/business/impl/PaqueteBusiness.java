package com.soa.service.booking.business.impl;

import java.util.List;

import org.springframework.stereotype.Service;

import com.soa.service.booking.model.domain.PaqueteTuristico;
import com.soa.service.booking.repository.PaqueteTuristicoRepository;

import lombok.RequiredArgsConstructor;

@Service
@RequiredArgsConstructor
public class PaqueteBusiness {

	private final PaqueteTuristicoRepository repository;
	
	public PaqueteTuristico registrar(PaqueteTuristico paqueteTuristico) {
		return repository.save(paqueteTuristico);
	}
	
	public List<PaqueteTuristico> listPaqueteTuristico() {
		return repository.findAll();
	}
}
