
class Property:
    """
    Base Property class
    """
    def __init__(self, name):
        self.Name = name #Unique name
        self.Properties = dict() #One or many subproperties or properties

    def getAllByType(self, type):
        """
        get all properties by type
        """
        if not self.Properties:
            if isinstance(self, type):
                return self
        allProp = []
        for key in self.Properties:
            if isinstance(self.Properties[key], type):
                allProp.append(self.Properties[key].getAllByType(type))
        return allProp

    def getByName(self, name):
        """
        get first property by name
        """
        if not self.Properties:
            if self.Name == name:
                return self
            else:
                return None
        if name in self.Properties:
            return self.Properties[name]
        for prop in self.Properties.itervalues():
            ans = prop[name]
            if not ans is None:
                return ans
        return None

    def __getitem__(self, item):
        return self.getByName(item)

    def __str__(self):
        chs = self.getAllByType(Characteristic)
        s = '\n'.join(['Characteristic: Type-'+c.Type+' Name-'+c.Name+' Value-'+str(c.Value) for c in chs])
        return s


class Characteristic(Property):
    """
    class of Characteristic Property
    """
    def __init__(self, name):
        Property.__init__(self, name)
        self.Type = None # Variable type of value
        self.Value = None
        self.Max = None
        self.Min = None

    #arithmetic functions
    def __iadd__(self, other):
        if not isinstance(other, int):
            other = other.Value
        self.Value += other
        if not (self.Max is None):
            self.Value = min(self.Max, self.Value)
        if not (self.Min is None):
            self.Value = max(self.Min, self.Value)

    def __isub__(self, other):
        self.Value -= other
        if not (self.Max is None):
            self.Value = min(self.Max, self.Value)
        if not (self.Min is None):
            self.Value = max(self.Min, self.Value)

    def __eq__(self, other):
        return self.Value == other

    def __ne__(self, other):
        return self.Value != other

    def __gt__(self, other):
        return self.Value > other

    def __lt__(self, other):
        return self.Value < other

    def __str__(self):
        return 'Characteristic: Type-'+self.Type+' Name-'+self.Name+' Value-'+str(self.Value)


class Objectivity(Property):
    actionName = []
    #Name of action which may be applied to agent

    def __init__(self, name, action):
        Property.__init__(self, name)
        self.actionName = action


class Subjectivity(Property):
    Action = []
    #Name of action which may be applied by agent

    def __init__(self, name, action):
        Property.__init__(self, name)
        self.Action = action


class Reactivity(Property):
    TriggerAction = []
    #Name or Type of action, which will lead to usage
    Action = []
    #Name of action, which will follow trigger
    ActionArgs = []
    #Args of Action ! My be incapsulated in Action


class Periodicity(Property):
    def __init__(self, name, action, timeInterval):
        Property.__init__(self, name)
        #action, which will be repeated
        self.Action = action
        # Peridiosity
        self.TimeInterval = timeInterval
        self.curTimerTime = timeInterval

    def __call__(self):
        self.Perform()

    def Perform(self):
        self.curTimerTime -= 1
        if self.curTimerTime == 0:
            self.Action()
            self.curTimerTime = self.TimeInterval

class Feeling(Property):
    Action = []
    #Name of action, which will be repeated before every turn as feeling


class Memory(Property):
    pass

