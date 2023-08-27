package hr.algebra.dao;

import hr.algebra.model.Job;
import hr.algebra.model.Person;
import java.util.List;

public interface Repository {
    int addPerson(Person data) throws Exception;
    void updatePerson(Person person) throws Exception;
    void deletePerson(Person person) throws Exception;
    Person getPerson(int idPerson) throws Exception;
    List<Person> getPeople() throws Exception;
    List<Job> getJobs() throws Exception;
    int addJob(Job data) throws Exception;
    void deleteJob(Job job) throws Exception;
    Job getJob(int idJob) throws Exception;
    void updateJob(Job job) throws Exception;
    default void release() throws Exception {}
}
