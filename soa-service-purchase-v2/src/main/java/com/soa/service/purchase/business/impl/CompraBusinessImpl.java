package com.soa.service.purchase.business.impl;

import java.util.List;

import org.springframework.stereotype.Service;

import com.soa.service.purchase.business.CompraBusiness;
import com.soa.service.purchase.model.domain.Compra;
import com.soa.service.purchase.model.domain.Estado;
import com.soa.service.purchase.model.domain.Reserva;
import com.soa.service.purchase.model.dto.CompraResponseDTO;
import com.soa.service.purchase.proxy.ReservaApi;
import com.soa.service.purchase.repository.CompraRepository;

import lombok.RequiredArgsConstructor;
import retrofit2.Call;

@Service
@RequiredArgsConstructor
public class CompraBusinessImpl implements CompraBusiness{

	private final CompraRepository repository;
	private final ReservaApi api;
	
	@Override
	public List<Compra> listar() {
		return repository.findAll();
	}

	@Override
	public Compra procesar(Compra compra) throws Exception {
		compra.setEstado(Estado.ACEPTADO);
		return repository.save(compra);
	}

	@Override
	public CompraResponseDTO compraPorId(Integer id) {
		return repository.findById(id)
			.map(cf -> {
				Reserva reserva;
				try {
					reserva = reserva(cf.getCompraId());
					return  CompraResponseDTO.builder()
							.compraId(cf.getCompraId())
							.reservaId(cf.getReservaId())
							.cantidadPersonas(reserva.getCantidadPersonas())
							.fechaInicio(reserva.getFechaInicio())
							.fechaFin(reserva.getFechaFin())
							.titulo(reserva.getTitulo())
							.precio(reserva.getPrecio())
							.duracion(reserva.getDuracion())
							.fecha(reserva.getFecha())
							.estado(cf.getEstado())
							.build();
				} catch (Exception e) {
					e.printStackTrace();
					return new CompraResponseDTO();
				}
			}).orElseThrow(() -> new IllegalArgumentException());
	}
	
	@Override
	public void cancelar(Integer id) {
		repository.deleteById(id);
	}

	private Reserva reserva(Integer id) throws Exception {
		Call<Reserva> res = api.obtenerReserva(id);
		Reserva r = res.execute().body();
		return Reserva.builder()
			.reservaId(r.getReservaId())
			.cantidadPersonas(r.getCantidadPersonas())
			.fechaInicio(r.getFechaInicio())
			.fechaFin(r.getFechaFin())
			.titulo(r.getTitulo())
			.precio(r.getPrecio())
			.duracion(r.getDuracion())
			.fecha(r.getFecha())
			.estado(r.getEstado())
			.build();
	}
}
