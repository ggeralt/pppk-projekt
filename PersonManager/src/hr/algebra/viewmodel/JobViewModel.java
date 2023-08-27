package hr.algebra.viewmodel;

import hr.algebra.model.Job;
import javafx.beans.property.IntegerProperty;
import javafx.beans.property.SimpleIntegerProperty;
import javafx.beans.property.SimpleStringProperty;
import javafx.beans.property.StringProperty;

public class JobViewModel {
    private final Job job;
    
    public JobViewModel(Job job){
        if(job == null){
            job = new Job(0, "");
        }
        
        this.job = job;
    }
    
    public Job getJob(){
        return job;
    }
    
    public IntegerProperty getIdJobProperty(){
        return new SimpleIntegerProperty(job.getIDJob());
    }
    
    public StringProperty getNameProperty(){
        return new SimpleStringProperty(job.getName());
    }

    @Override
    public String toString() {
        return job.toString();
    }
}
