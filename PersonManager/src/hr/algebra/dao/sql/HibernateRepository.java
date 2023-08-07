package hr.algebra.dao.sql;

import hr.algebra.dao.Repository;
import hr.algebra.model.Person;
import java.util.List;
import javax.persistence.EntityManager;

public class HibernateRepository implements Repository {

    @Override
    public void release() throws Exception {
        HibernateFactory.release();
    }
    
    @Override
    public int addPerson(Person data) throws Exception {
        try(EntityManagerWrapper entityManagerWrapper = HibernateFactory.getEntityManager()) {
            EntityManager entityManager =  entityManagerWrapper.get();
            
            entityManager.getTransaction().begin();
            Person person = new Person(data);
            entityManager.persist(person);
            entityManager.getTransaction().commit();
            
            return person.getIDPerson();
        }
    }

    @Override
    public void updatePerson(Person person) throws Exception {
        try(EntityManagerWrapper entityManagerWrapper = HibernateFactory.getEntityManager()) {
            EntityManager entityManager =  entityManagerWrapper.get();
            
            entityManager.getTransaction().begin();
            entityManager.find(Person.class, person.getIDPerson()).updateDetails(person);
            entityManager.getTransaction().commit();
        }
    }

    @Override
    public void deletePerson(Person person) throws Exception {
        try(EntityManagerWrapper entityManagerWrapper = HibernateFactory.getEntityManager()) {
            EntityManager entityManager =  entityManagerWrapper.get();
            
            entityManager.getTransaction().begin();
            entityManager.remove(entityManager.contains(person) ? person : entityManager.merge(person));
            entityManager.getTransaction().commit();
        }
    }

    @Override
    public Person getPerson(int idPerson) throws Exception {
        try(EntityManagerWrapper entityManagerWrapper = HibernateFactory.getEntityManager()) {
            EntityManager entityManager =  entityManagerWrapper.get();
            
            return entityManager.find(Person.class, idPerson);
        }
    }

    @Override
    public List<Person> getPeople() throws Exception {
        try(EntityManagerWrapper entityManagerWrapper = HibernateFactory.getEntityManager()) {
            EntityManager entityManager =  entityManagerWrapper.get();
            
            return entityManager.createNamedQuery(HibernateFactory.SELECT_PEOPLE).getResultList();
        }
    }
}
