package hr.algebra.dao.sql;

import hr.algebra.dao.Repository;
import hr.algebra.model.Job;
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

    @Override
    public List<Job> getJobs() throws Exception {
        try (EntityManagerWrapper entityManager = HibernateFactory.getEntityManager()) {
            return entityManager.get().createNamedQuery(HibernateFactory.SELECT_JOB).getResultList();
        } 
    }

    @Override
    public int addJob(Job data) throws Exception {
        try (EntityManagerWrapper entityManager = HibernateFactory.getEntityManager()) {
            EntityManager em = entityManager.get();
            em.getTransaction().begin();
            Job job = new Job(data);
            em.persist(job);
            em.getTransaction().commit();
            return job.getIDJob();
        }
    }

    @Override
    public void deleteJob(Job job) throws Exception {
        try (EntityManagerWrapper entityManager = HibernateFactory.getEntityManager()) {
            EntityManager em = entityManager.get();
            em.getTransaction().begin();
            em.remove(em.contains(job) ? job : em.merge(job));
            em.getTransaction().commit();
        }
    }

    @Override
    public Job getJob(int idJob) throws Exception {
        try (EntityManagerWrapper entityManager = HibernateFactory.getEntityManager()) {
            EntityManager em = entityManager.get();
            return em.find(Job.class, idJob);
        }
    }

    @Override
    public void updateJob(Job job) throws Exception {
        try (EntityManagerWrapper entityManager = HibernateFactory.getEntityManager()) {
            EntityManager em = entityManager.get();
            em.getTransaction().begin();
            em.find(Job.class, job.getIDJob()).updateDetails(job);
            em.getTransaction().commit();            
        }
    }
}
