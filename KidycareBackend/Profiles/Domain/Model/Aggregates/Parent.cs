﻿using KidycareBackend.Profiles.Domain.Model.Commands;
using KidycareBackend.Profiles.Domain.Model.ValueObjects;

namespace KidycareBackend.Profiles.Domain.Model.Aggregates;

public partial class Parent
{
    public int Id { get; private set; }
    public UserId userId { get; private set; }
    public string address { get; private set; }
    
    public string name { get; private set; }
    
    public string phone { get; private set; }
    public int childrenCount { get; private set; }
    
    public string preferences { get; private set; }
    
    public string city { get; private set; }

    protected Parent() { }

    public Parent(UserId userId, string address, string name, string phone, int childrenCount, string preferences, string city)
    {
        this.userId = userId;
        this.address = address;
        this.name = name;
        this.phone = phone;
        this.childrenCount = childrenCount;
        this.preferences = preferences;
        this.city = city;
    }

    public Parent(CreateParentCommand command)
    {
        userId = command.userId;
        address = command.address;
        name = command.name;
        phone = command.phone;
        childrenCount = command.childrenCount;
        preferences = command.preferences;
        city = command.city;
    }
}