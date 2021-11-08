package com.soa.service.booking.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.soa.service.booking.model.domain.Reserva;

@Repository
public interface ReservaRepository extends JpaRepository<Reserva, Integer> {

}
