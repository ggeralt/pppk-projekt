package hr.algebra.model;

import hr.algebra.dao.sql.HibernateFactory;
import java.io.Serializable;
import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.Table;
import javax.xml.bind.annotation.XmlRootElement;

@Entity
@Table(name = "Job")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = HibernateFactory.SELECT_JOB, query = "SELECT j FROM Job j")
})
public class Job implements Serializable {
    private static final long serialVersionUID = 1L;
    
    @Id
    @Basic(optional = false)
    @Column(name = "IDJob")
    @GeneratedValue(strategy = GenerationType.AUTO)
    private Integer IDJob;
    
    @Basic(optional = false)
    @Column(name = "Name")
    private String name;
    
    public Job(){}
    
    public Job(Job data){
        updateDetails(data);
    }

    public Job(Integer IDJob){
        this.IDJob = IDJob;
    }
    
    public Job(Integer IDJob, String name){
        this.IDJob = IDJob;
        this.name = name;
    }
    
    public Integer getIDJob() {
        return IDJob;
    }

    public void setIDJob(Integer IDSubject) {
        this.IDJob = IDJob;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public void updateDetails(Job data) {
        this.name = data.getName();
    }

    @Override
    public String toString() {
        return IDJob + " " + name;
    }
}
